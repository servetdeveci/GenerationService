import { Component, Inject, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PowerPlant } from '../../../Entities/power-plant';
import { DataService } from '../../services/data.service';

@Component({
  selector: 'app-delete-powerplant',
  templateUrl: './delete-powerplant.component.html'
})
export class DeletePowerPlantComponent implements OnInit {
  connectionMessage: string;
  statusClass: string;

  constructor(private route: ActivatedRoute, private service: DataService) { }
  id: string;
  delete: PowerPlant;
  submitted: boolean = false;

  ngOnInit() {
    this.id = this.route.snapshot.paramMap.get('id');

    this.service.getPowerPlantDetail(this.id).subscribe(data => {
      this.delete = data;
    });

  }
  save() {
    this.service.delete(this.delete.id)
      .subscribe(
        response => {
          console.log(response);
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
          this.connectionMessage = "Servise bağlanılırken hata oluştu."
          this.statusClass = "text-danger";
        });
   
  }

}
