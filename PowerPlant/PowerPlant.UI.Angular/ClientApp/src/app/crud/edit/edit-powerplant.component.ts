import { Component, Inject, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PowerPlant } from '../../../Entities/power-plant';
import { DataService } from '../../services/data.service';

@Component({
  selector: 'app-edit-powerplant',
  templateUrl: './edit-powerplant.component.html'
})
export class EditPowerPlantComponent implements OnInit {
  connectionMessage: string;
  statusClass: string;

  constructor(private route: ActivatedRoute, private service: DataService) { }
  id: string;
  edit: PowerPlant;
  submitted: boolean = false;

  ngOnInit() {
    this.id = this.route.snapshot.paramMap.get('id');
    this.service.getPowerPlantDetail(this.id).subscribe(data => {
      this.edit = data;
    });

  }
  save() {
    this.service.update(this.edit)
      .subscribe(
        response => {
          this.submitted = true;
          this.connectionMessage = "İşlem Başarılı.";
          this.statusClass = "text-success";
          if (response as number == 0) {
            console.log(response);
            this.connectionMessage = "Kayıt düzenlenirken hata oluştu."
            this.statusClass = "text-danger";
          }
        },
        error => {
          console.log(error);
          this.connectionMessage = "Hata oluştu."
          this.statusClass = "text-danger";
        });
  }

}
