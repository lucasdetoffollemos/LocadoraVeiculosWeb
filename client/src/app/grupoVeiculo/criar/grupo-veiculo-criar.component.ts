import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { IHttpGrupoVeiculoService } from 'src/app/shared/interfaces/IHttpGrupoVeiculoService';
import { ToastService } from 'src/app/shared/services/toast.service';
import { GrupoVeiculoCreateViewModel } from 'src/app/shared/viewModels/grupoVeiculo/GrupoVeiculoCreateViewModel';
import { GrupoVeiculoListarComponent } from '../listar/grupo-veiculo-listar.component';

@Component({
  selector: 'app-grupo-veiculo-criar',
  templateUrl: './grupo-veiculo-criar.component.html'
})
export class GrupoVeiculoCriarComponent implements OnInit {


  cadastroForm: FormGroup;
  grupoVeiculo: GrupoVeiculoCreateViewModel;

  constructor(@Inject('IHttpGrupoVeiculoServiceToken') private servicoGrupoVeiculo: IHttpGrupoVeiculoService, private router: Router, private toastService: ToastService) { }

  ngOnInit(): void {
    this.cadastroForm = new FormGroup({
      nome: new FormControl('', Validators.required),
      valorDia: new FormControl('', Validators.required),
      planoDiarioValorDia: new FormControl('', Validators.required),
      planoDiarioKmRodado: new FormControl('', Validators.required),
      planoInclusoValorDia: new FormControl('', Validators.required),
      planoInclusoKmIncluso: new FormControl('', Validators.required),
      planoInclusoKmRodado: new FormControl('', Validators.required),
      planoLivreValorDia: new FormControl('', Validators.required)
    });
  }

  adicionarGrupoVeiculo() {
    if(this.cadastroForm.valid){

      this.grupoVeiculo = Object.assign({}, this.grupoVeiculo, this.cadastroForm.value);
      
      this.servicoGrupoVeiculo.adicionarGrupoVeiculo(this.grupoVeiculo)
      .subscribe(grupoVeiculo => {
          this.toastService.show('Grupo Veiculo ' + grupoVeiculo.nome + ' adicionado com sucesso!',
            { classname: 'bg-success text-light', delay: 5000 });
          setTimeout(() => {
            this.router.navigate(['grupoVeiculo/listar']);
          }, 5000);
        },
        erro => {
          for(let nomeErro in erro.error.errors){
            const mensagemErro = erro.error.errors[nomeErro];
            this.toastService.show('Erro ao adicionar grupo veiculo: ' + mensagemErro,
            { classname: 'bg-danger text-light', delay: 5000 });
          }
        });
    }
   
  }

  cancelar(): void {
    this.router.navigate(['grupoVeiculo/listar']);
  }
}
