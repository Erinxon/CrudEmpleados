import { HttpClient } from "@angular/common/http";
import { AbstractControl } from "@angular/forms";
import { EmpledoService } from "../services/empledo-service.service";
import { ValidationCedula } from "./validationCedula";

export class MyValidations{
    static isCedulaInvalid(control: AbstractControl){
        const validationCedula = new ValidationCedula();
        if(!validationCedula.isValida(control.value)){
            return { isCedulaInvalid: true, actualCedula: control.value}
        }
        return null;
    }
}