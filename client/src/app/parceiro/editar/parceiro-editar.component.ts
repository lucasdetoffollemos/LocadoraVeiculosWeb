import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { IHttpParceiroService } from 'src/app/shared/interfaces/IHttpParceiroService';
import { CupomListViewModel } from 'src/app/shared/viewModels/cupom/CupomListViewModel';
import { ParceiroDetailsViewModel } from 'src/app/shared/viewModels/parceiro/ParceiroDetailsViewModel';
import { ParceiroEditViewModel } from 'src/app/shared/viewModels/parceiro/ParceiroEditViewModel';

@Component({
  selector: 'app-parceiro-editar',
  templateUrl: './parceiro-editar.component.html'
})
export class ParceiroEditarComponent implements OnInit {

  sub: any;
  id: any;
  parceiro: ParceiroEditViewModel;
  cupons: CupomListViewModel[];
  cadastroForm: FormGroup;

  constructor(private _Activatedroute: ActivatedRoute, @Inject('IHttpParceiroServiceToken') private servicoParceiro: IHttpParceiroService, private router: Router) { }

  ngOnInit(): void {
    this.id = this._Activatedroute.snapshot.paramMap.get("id");

    this.cadastroForm = new FormGroup({
      id: new FormControl(''),
      nome: new FormControl('')
    });

    this.carregarParceiro();
  }

  carregarParceiro() {
    this.servicoParceiro.obterParceiroPorId(this.id)
      .subscribe((parceiro: ParceiroDetailsViewModel) => {
        this.carregarFormulario(parceiro);
      });
  }

  atualizarParceiro() {
    this.parceiro = Object.assign({}, this.parceiro, this.cadastroForm.value);
    this.parceiro.id = this.id;

    this.servicoParceiro.editarParceiro(this.parceiro)
      .subscribe(() => {
        this.router.navigate(['parceiro/listar']);
      });
  }

  cancelar(): void {
    this.router.navigate(['parceiro/listar']);
  }

  carregarFormulario(parceiro: ParceiroDetailsViewModel) {

    this.cadastroForm = new FormGroup({
      id: new FormControl(parceiro.id),
      nome: new FormControl(parceiro.nome),
    });

    this.cupons = parceiro.cupons;
  }
}
