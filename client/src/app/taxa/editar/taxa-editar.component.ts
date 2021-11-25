import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { IHttpTaxaService } from 'src/app/shared/interfaces/IHttpTaxaService';
import { TaxaType } from 'src/app/shared/models/TaxaEnum';
import { ToastService } from 'src/app/shared/services/toast.service';
import { TaxaDetailsViewModel } from 'src/app/shared/viewModels/taxa/TaxaDetailsViewModel';
import { TaxaEditViewModel } from 'src/app/shared/viewModels/taxa/TaxaEditViewModel';

@Component({
  selector: 'app-taxa-editar',
  templateUrl: './taxa-editar.component.html'
})
export class TaxaEditarComponent implements OnInit {

  cadastroForm: FormGroup;
  id: any;
  taxa: TaxaEditViewModel;
  

  tiposTaxa = TaxaType;
  chaves: any[];

  constructor(private _Activatedroute: ActivatedRoute,
    @Inject('IHttpTaxaServiceToken') private servicoTaxa: IHttpTaxaService,
    private router: Router, private toastService: ToastService) { }

  ngOnInit(): void {
    this.id = this._Activatedroute.snapshot.paramMap.get("id");

    this.chaves = Object.keys(this.tiposTaxa).filter(t => !isNaN(Number(t)));

    this.cadastroForm = new FormGroup({
      id: new FormControl(''),
      nome: new FormControl(''),
      valor: new FormControl(''),
      tipoTaxa: new FormControl('')
    });

    this.carregarTaxas();
  }

  carregarTaxas(): void {
    this.servicoTaxa.obterTaxaPorId(this.id)
      .subscribe((taxa: TaxaDetailsViewModel) => {
        this.carregarFormulario(taxa);
      });
  }
  carregarFormulario(taxa: TaxaDetailsViewModel) {

    this.cadastroForm = new FormGroup({
      id: new FormControl(taxa.id),
      nome: new FormControl(taxa.nome, Validators.required),
      valor: new FormControl(taxa.valor, Validators.compose([Validators.required, Validators.min(1)])),
      tipoTaxa: new FormControl(taxa.tipoTaxa, Validators.required)
    });
  }

  atualizarTaxa() {
    this.taxa = Object.assign({}, this.taxa, this.cadastroForm.value);
    this.taxa.id = this.id;

    this.servicoTaxa.editarTaxa(this.taxa)
    .subscribe(
      taxa => {
        this.toastService.show('Taxa ' + taxa.nome + ' editada com sucesso!',
          { classname: 'bg-success text-light', delay: 5000 });
        setTimeout(() => {
          this.router.navigate(['taxa/listar']);
        }, 5000);
      },
      erro => {
        for(let nomeErro in erro.error.errors){
          const mensagemErro = erro.error.errors[nomeErro];
          this.toastService.show('Erro ao editar cupom: ' + mensagemErro,
          { classname: 'bg-danger text-light', delay: 5000 });
        }
      });
  }

  cancelar(): void {
    this.router.navigate(['taxa/listar']);
  }

}
