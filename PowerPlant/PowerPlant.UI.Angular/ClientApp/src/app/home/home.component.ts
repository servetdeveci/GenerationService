import { Component, OnDestroy, OnInit } from '@angular/core';
import { interval, Subject } from 'rxjs';
import { PowerPlant } from '../../Entities/power-plant';
import { DataService } from '../services/data.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnDestroy, OnInit {

  dtOptions: DataTables.Settings = {};
  powerPlants: PowerPlant[] = [];
  closeModal: string;
  connectionMessage: string;
  // We use this trigger because fetching the list of persons can be quite long,
  // thus we ensure the data is fetched before rendering
  dtTrigger: Subject<any> = new Subject<any>();
    submitted: boolean;

  constructor(private service: DataService) { }

  ngOnInit(): void {
    this.dtOptions = {
      pagingType: 'full_numbers',
      pageLength: 10,
      order: [2, 'desc'],
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

    this.service.getAllPowerPlants().subscribe(
      result => {
        this.connectionMessage = "";
        this.powerPlants = result;
        this.dtTrigger.next();
      },
      error => {
        console.log(error);
        this.connectionMessage = "Servise bağlanırken hata oluştu."
      },
      () => {
      });


  }
  delete(id: string): void {
    this.service.delete(id).subscribe(
        result => {
          this.submitted = true;
          this.connectionMessage = "";
          if (result == false) {
            this.connectionMessage = "Kayıt silinirken hata oluştu."
          }
        },
        error => {
          console.log(error);
          this.connectionMessage = "Servise bağlanırken hata oluştu."
        },
        () => {
        });

  }
  ngOnDestroy(): void {
    // Do not forget to unsubscribe the event
    this.dtTrigger.unsubscribe();
  }

}
