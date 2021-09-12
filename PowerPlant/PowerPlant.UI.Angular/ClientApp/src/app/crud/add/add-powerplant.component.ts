import { Component } from '@angular/core';
import { PowerPlant } from '../../../Entities/power-plant';
import { DataService } from '../../services/data.service';

@Component({
  selector: 'app-add-powerplant',
  templateUrl: './add-powerplant.component.html'
})
export class AddPowerPlantComponent {
  added: PowerPlant = { id: "id", webId: "isim" };

  submitted: boolean = false;
  connectionMessage: string;
  statusClass: string;

  constructor(private service: DataService) { }

  save() {
    this.service.create(this.added).subscribe(
      response => {
        this.submitted = true;
        this.connectionMessage = "İşlem Başarılı.";
        this.statusClass = "text-success";
        if (response as number == 0) {
          this.connectionMessage = "Kayıt oluşturulurken hata oluştu."
          this.statusClass = "text-danger";
        }
      },
      error => {
        console.log(error);
        this.connectionMessage = "Hata oluştu."
        this.statusClass = "text-danger";
      }
    );

  }

}
