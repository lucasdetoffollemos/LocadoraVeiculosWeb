import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { IHttpFuncionarioService } from 'src/app/shared/interfaces/IHttpFuncionarioService';
import { ToastService } from 'src/app/shared/services/toast.service';
import { FuncionarioCreateViewModel } from 'src/app/shared/viewModels/funcionario/FuncionarioCreateViewModel';

@Component({
  selector: 'app-funcionario-criar',
  templateUrl: './funcionario-criar.component.html'
})
export class FuncionarioCriarComponent implements OnInit {
  
  cadastroForm: FormGroup;
  funcionario: FuncionarioCreateViewModel;

  constructor(@Inject('IHttpFuncionarioServiceToken') private servicoFuncionario: IHttpFuncionarioService, private router: Router, private toastService: ToastService) { }

  ngOnInit(): void {
    this.cadastroForm = new FormGroup({
      nome: new FormControl(''),
      dataAdmissao: new FormControl(''),
      salario: new FormControl(''),
      usuario: new FormControl(''),
      senha: new FormControl('')
    });
  }

  adicionarFuncionario() {
    this.funcionario = Object.assign({}, this.funcionario, this.cadastroForm.value);

    this.servicoFuncionario.adicionarFuncionario(this.funcionario)
    .subscribe(
      funcionario => {
        this.toastService.show('Funcionario ' + funcionario.nome + ' adicionado com sucesso!',
          { classname: 'bg-success text-light', delay: 5000 });
        setTimeout(() => {
          this.router.navigate(['funcionario/listar']);
        }, 5000);
      },
      erro => {
        for(let nomeErro in erro.error.errors){
          const mensagemErro = erro.error.errors[nomeErro];
          this.toastService.show('Erro ao adicionario funcionario: ' + mensagemErro,
          { classname: 'bg-danger text-light', delay: 5000 });
        }
      });
  }

  cancelar(): void {
    this.router.navigate(['funcionario/listar']);
  }

}
