import { Component, Input } from "@angular/core";
import { FormGroup } from "@angular/forms";

@Component({
    selector: 'form-errors',
    template: `
        <div *ngIf="errorMessages !== null">{{errorMessages}}</div>
    `
})

export class FormErrorsComponent{
    @Input() form: FormGroup | undefined
    @Input() errorMsgs: string[] | undefined;

    get errorMessages(){
        if(this.form == undefined || this.errorMsgs == undefined) return null;

        return this.errorMsgs;

        // const control = this.form.get(this.fieldId);
        // for(let propertyName in control?.errors){
        //     if(control?.errors.hasOwnProperty(propertyName) && control.touched){
        //         control.errors
        //         return control.errors;
        //     }
        // }

        // return null;
    }
}