using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiEmpleado.DTOs.DireccionDtos;
using ApiEmpleado.DTOs.EmpleadoDtos;
using ApiEmpleado.Entities;
using ApiEmpleado.Pagination;
using ApiEmpleado.Repositories;
using ApiEmpleado.Repository;
using ApiEmpleado.Response;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiEmpleado.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class EmpleadosController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmpleadosController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<PagedResponse<IEnumerable<EmpleadoDto>>>> GetAll([FromQuery] RequestParameter pagination)
        {
            var response = new PagedResponse<IEnumerable<EmpleadoDto>>();
            try
            {
                var empleados = await this._unitOfWork.EmpleadoRepository.GetAll();
                
                var empleadosDto = empleados.Select(e => new EmpleadoDto
                {
                    Id = e.Id, Nombre = e.Nombre, Apellido = e.Apellido, FechaNacimiento = e.FechaNacimiento,
                    Cargo = e.Cargo, Departamento = e.Departamento, Salario = e.Salario, IsActive = e.IsActive,
                    Direccion = _mapper.Map<DireccionDto>(_unitOfWork.DireccionRepository.GetById(e.DireccionId).Result)
                }).Skip((pagination.PageNumber - 1) * pagination.PageSize).Take(pagination.PageSize);
                
                response.TotalRegistros = this._unitOfWork.EmpleadoRepository.GetCount();
                response.PageNumber = pagination.PageNumber;
                response.PageSize = pagination.PageSize;
                response.Data = empleadosDto;
            }
            catch (Exception e)
            {
                response.Succeeded = false;
                response.Message = $"Ha ocurrido un error Inesperado";
                return BadRequest(response);
            }
            
            return Ok(response);
        }

        [HttpGet("{id:Guid}")]
        public async Task<ActionResult<ApiResponse<EmpleadoDto>>> GetById(Guid id)
        {
            var response = new ApiResponse<EmpleadoDto>();
            try
            {
                var empleado = await this._unitOfWork.EmpleadoRepository.GetById(id);
                if (empleado is null)
                {
                    response.Succeeded = false;
                    response.Message = "Empleado no encontrado!";
                    return BadRequest(response);
                }
                var empleadoDto = _mapper.Map<EmpleadoDto>(empleado);
                empleadoDto.Direccion = _mapper.
                    Map<DireccionDto>(_unitOfWork.DireccionRepository.
                        GetById(empleado.DireccionId).Result);
                response.Data = empleadoDto;
            }
            catch (Exception e)
            {
                response.Succeeded = false;
                response.Message = $"Ha ocurrido un error Inesperado";
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AddEmpleadoDto empleadoDto)
        {
            var response = new ApiResponse<EmpleadoDto>();
            try
            {
                var direccion = await this._unitOfWork.DireccionRepository.Add(_mapper.Map<Direccion>(empleadoDto.Direccion));
                empleadoDto.DireccionId = direccion.Id;
                var empleado = await this._unitOfWork.EmpleadoRepository.Add(_mapper.Map<Empleado>(empleadoDto));
                await _unitOfWork.SavechangesAsync();
                response.Data = _mapper.Map<EmpleadoDto>(empleado);
            }
            catch (Exception e)
            {
                response.Succeeded = false;
                response.Message = $"Ha ocurrido un error Inesperado";
                return BadRequest(response);
            }
            return Created("",response);
        }
        
        [HttpPut("{id:Guid}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] UpdateEmpleadoDto empleadoDto)
        {
            var response = new ApiResponse<int>();
            try
            {
                var empleatoToUpdate = await this._unitOfWork.EmpleadoRepository.GetById(id);
                if (empleatoToUpdate is null)
                {
                    response.Succeeded = false;
                    response.Message = "Empleado no encontrado!";
                    return BadRequest(response);
                }

                var empleado = _mapper.Map<Empleado>(empleadoDto);
                empleado.Id = id;
                empleado.DireccionId = empleatoToUpdate.DireccionId;
                await this._unitOfWork.EmpleadoRepository.Update(empleado);
                
                var direccion = _mapper.Map<Direccion>(empleadoDto.Direccion);
                await this._unitOfWork.DireccionRepository.Update(direccion);
                
                var resultUpdate = await _unitOfWork.SavechangesAsync();
                response.Data = resultUpdate > 0 ? 1 : 0;
            }
            catch (Exception e)
            {
                response.Succeeded = false;
                response.Message = $"Ha ocurrido un error Inesperado";
                return BadRequest(response);;
            }
            return Ok(response);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var response = new ApiResponse<int>();
            try
            {
                var empleado = await this._unitOfWork.EmpleadoRepository.GetById(id);
             
                if (empleado is null)
                {
                    response.Succeeded = false;
                    response.Message = "Empleado no encontrado!";
                    return BadRequest(response);
                }
                
                var direccionEmpleado = await this._unitOfWork.DireccionRepository.
                    GetById(empleado.DireccionId);
                await this._unitOfWork.EmpleadoRepository.Remove(empleado);
                await this._unitOfWork.DireccionRepository.Remove(direccionEmpleado);
                response.Data = await _unitOfWork.SavechangesAsync();
            }
            catch (Exception e)
            {
                response.Succeeded = false;
                response.Message = $"Ha ocurrido un error Inesperado";
                return BadRequest(response);
            }

            return Ok(response);
        }
        
        [HttpGet("search")]
        public async Task<ActionResult<PagedResponse<IEnumerable<EmpleadoDto>>>> FilterEmpleado([FromQuery] string search)
        {
            var response = new PagedResponse<IEnumerable<EmpleadoDto>>();
            try
            {
                var empleados = await this._unitOfWork.EmpleadoRepository.
                    Find(e => e.Nombre.Contains(search) || e.Apellido.Contains(search) );
                var empleadosDto = empleados.Select(e => new EmpleadoDto
                {
                    Id = e.Id, Nombre = e.Nombre, Apellido = e.Apellido, FechaNacimiento = e.FechaNacimiento,
                    Cargo = e.Cargo, Departamento = e.Departamento, Salario = e.Salario, IsActive = e.IsActive,
                    Direccion = _mapper.Map<DireccionDto>(_unitOfWork.DireccionRepository.GetById(e.DireccionId).Result)
                });
                response.Data = empleadosDto;
               
            }
            catch (Exception e)
            {
                response.Succeeded = false;
                response.Message = $"Ha ocurrido un error Inesperado";
                return BadRequest(response);
            }
            return Ok(response);
        }


    }
}