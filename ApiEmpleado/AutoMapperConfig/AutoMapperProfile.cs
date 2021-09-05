using ApiEmpleado.DTOs.DireccionDtos;
using ApiEmpleado.DTOs.EmpleadoDtos;
using ApiEmpleado.Entities;
using AutoMapper;

namespace ApiEmpleado.AutoMapperConfig
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            #region Direccion
            CreateMap<DireccionDto, Direccion>().ReverseMap();
            CreateMap<AddDireccionDto, Direccion>().ReverseMap();
            CreateMap<UpdateDireccionDto, Direccion>().ReverseMap();
            #endregion

            #region Empleado
            CreateMap<Empleado, EmpleadoDto>().ReverseMap();
            CreateMap<AddEmpleadoDto, Empleado>().ReverseMap();
            CreateMap<UpdateEmpleadoDto, Empleado>().ReverseMap();
            #endregion
        }
    }
}