import { Component, Inject, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subject } from 'rxjs';
import { PowerPlant } from '../../../Entities/power-plant';
import { PowerPlantDatum } from '../../../Entities/power-plant-datum';
import { DataService } from '../../services/data.service';

@Component({
  selector: 'app-detail-powerplant',
  templateUrl: './detail-powerplant.component.html'
})
export class DetailPowerPlantComponent implements OnInit {

  constructor(private route: ActivatedRoute, private service: DataService) { }
  id: string;
  detail: PowerPlant;

  dtOptions: DataTables.Settings = {};
  powerPlantData: PowerPlantDatum[] = [];
  closeModal: string;
  connectionMessage: string;
  // We use this trigger because fetching the list of persons can be quite long,
  // thus we ensure the data is fetched before rendering
  dtTrigger: Subject<any> = new Subject<any>();
  submitted: boolean;

  ngOnInit() {
    this.id = this.route.snapshot.paramMap.get('id');
    this.service.getPowerPlantDetail(this.id).subscribe(data => {
      this.detail = data;
    });

    this.dtOptions = {
      pagingType: 'full_numbers',
      pageLength: 10,
      order: [3, 'desc'],
      language: {
        "emptyTable": "Tabloda herhangi bir veri mevcut değil",
        "info": "_TOTAL_ kayıttan _START_ - _END_ arasındaki kayıtlar gösteriliyor",
        "infoEmpty": "Kayıt yok",
        "infoFiltered": "(_MAX_ kayıt içerisinden bulunan)",
        "lengthMenu": "Sayfada _MENU_ kayıt göster",
        "loadingRecords": "Yükleniyor...",
        "processing": "İşleniyor...",
        "search": "Ara:",
        "zeroRecords": "Eşleşen kayıt bulunamadı",
        "paginate": {
          "first": "İlk",
          "last": "Son",
          "next": "Sonraki",
          "previous": "Önceki"
        },
        "aria": {
          "sortAscending": ": artan sütun sıralamasını aktifleştir",
          "sortDescending": ": azalan sütun sıralamasını aktifleştir"
        },

      }
    };

    this.service.getPowerPlantData(this.id).subscribe(
      result => {
        this.connectionMessage = "";
        this.powerPlantData = result;
        this.dtTrigger.next();
      },
      error => {
        console.log(error);
        this.connectionMessage = "Servise bağlanırken hata oluştu."
      },
      () => {
      });

  }
}
