import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { IHttpParceiroService } from 'src/app/shared/interfaces/IHttpParceiroService';
import { ToastService } from 'src/app/shared/services/toast.service';
import { ParceiroCreateViewModel } from 'src/app/shared/viewModels/parceiro/ParceiroCreateViewModel';

@Component({
  selector: 'app-parceiro-criar',
  templateUrl: './parceiro-criar.component.html'
})
export class ParceiroCriarComponent implements OnInit {

  cadastroForm: FormGroup;
  parceiro: ParceiroCreateViewModel;

  constructor(@Inject('IHttpParceiroServiceToken') private servicoParceiro: IHttpParceiroService, private router: Router, private toastService: ToastService) { }

  ngOnInit(): void {
    this.cadastroForm = new FormGroup({
      nome: new FormControl('')
    });
  }

  adicionarParceiro() {
    this.parceiro = Object.assign({}, this.parceiro, this.cadastroForm.value);

    this.servicoParceiro.adicionarParceiro(this.parceiro)
    .subscribe(
      parceiro => {
        this.toastService.show('Parceiro ' + parceiro.nome + ' adicionado com sucesso!',
          { classname: 'bg-success text-light', delay: 5000 });
        setTimeout(() => {
          this.router.navigate(['parceiro/listar']);
        }, 5000);
      },
      erro => {
        for(let nomeErro in erro.error.errors){
          const mensagemErro = erro.error.errors[nomeErro];
          this.toastService.show('Erro ao adicionar parceiro: ' + mensagemErro,
          { classname: 'bg-danger text-light', delay: 5000 });
        }
      });
  }

  cancelar(): void {
    this.router.navigate(['parceiro/listar']);
  }
}
