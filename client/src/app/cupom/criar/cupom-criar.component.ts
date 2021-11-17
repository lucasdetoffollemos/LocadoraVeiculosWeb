import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { Cupom } from 'src/app/shared/models/Cupom';
import { NgbDateStruct } from '@ng-bootstrap/ng-bootstrap';
import { CupomType } from 'src/app/shared/models/CupomEnum';
import { IHttpParceiroService } from 'src/app/shared/interfaces/IHttpParceiroService';
import { ParceiroListViewModel } from 'src/app/shared/viewModels/parceiro/ParceiroListViewModel';
import { CupomCreateViewModel } from 'src/app/shared/viewModels/cupom/CupomCreateViewModel';
import { IHttpCupomService } from 'src/app/shared/interfaces/IHttpCupomService';

@Component({
  selector: 'app-cupom-criar',
  templateUrl: './cupom-criar.component.html'
})
export class CupomCriarComponent implements OnInit {

  cadastroForm: FormGroup;
  dataValidade: NgbDateStruct;

  cupom: CupomCreateViewModel;
  listaParceiros: ParceiroListViewModel[];

  tipos = CupomType;
  chaves: any[];

  constructor(@Inject('IHttpCupomServiceToken') private servicoCupom: IHttpCupomService,
    @Inject('IHttpParceiroServiceToken') private servicoParceiro: IHttpParceiroService,
    private router: Router) { }

  ngOnInit(): void {
    this.chaves = Object.keys(this.tipos).filter(t => !isNaN(Number(t)));

    this.cadastroForm = new FormGroup({
      nome: new FormControl(''),
      valor: new FormControl(''),
      valorMinimo: new FormControl(''),
      dataValidade: new FormControl(''),
      parceiroId: new FormControl(''),
      tipo: new FormControl('')
    });

    this.carregarParceiros();
  }

  adicionarCupom() {
    this.cupom = Object.assign({}, this.cupom, this.cadastroForm.value);

    this.servicoCupom.adicionarCupom(this.cupom)
      .subscribe(() => {
        this.router.navigate(['cupom/listar']);
      });
  }

  carregarParceiros(): void {
    this.servicoParceiro.obterParceiros()
      .subscribe(parceiros => {
        this.listaParceiros = parceiros;
      });
  }

  cancelar(): void {
    this.router.navigate(['cupom/listar']);
  }
}
