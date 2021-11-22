import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { IHttpFuncionarioService } from 'src/app/shared/interfaces/IHttpFuncionarioService';
import { ToastService } from 'src/app/shared/services/toast.service';
import { FuncionarioDetailsViewModel } from 'src/app/shared/viewModels/funcionario/FuncionarioDetailsViewModel';
import { FuncionarioEditViewModel } from 'src/app/shared/viewModels/funcionario/FuncionarioEditViewModel';

@Component({
  selector: 'app-editar-funcionario',
  templateUrl: './editar-funcionario.component.html'
})
export class EditarFuncionarioComponent implements OnInit {

  sub: any;
  id: any;
  funcionario: FuncionarioEditViewModel;
  cadastroForm: FormGroup;

  constructor(private _Activatedroute: ActivatedRoute, @Inject('IHttpFuncionarioServiceToken') private servicoFuncionario: IHttpFuncionarioService, private router: Router, private toastService:ToastService) { }

  ngOnInit(): void {
    this.id = this._Activatedroute.snapshot.paramMap.get("id");

    this.cadastroForm = new FormGroup({
      id: new FormControl(''),
      nome: new FormControl(''),
      dataAdmissao: new FormControl(''),
      salario:new FormControl(''),
      usuario: new FormControl(''),
      senha: new FormControl('')
    });

    this.carregarFuncionario();
  }

  atualizarFuncionario() {
    this.funcionario = Object.assign({}, this.funcionario, this.cadastroForm.value);
    this.funcionario.id = this.id;

    

    this.servicoFuncionario.editarFuncionario(this.funcionario)
    .subscribe(
      funcionario => {
        this.toastService.show('Funcionario ' + funcionario.nome + ' editado com sucesso!',
          { classname: 'bg-success text-light', delay: 5000 });
        setTimeout(() => {
          this.router.navigate(['funcionario/listar']);
        }, 5000);
      },
      erro => {
        for(let nomeErro in erro.error.errors){
          const mensagemErro = erro.error.errors[nomeErro];
          this.toastService.show('Erro ao editar funcionario: ' + mensagemErro,
          { classname: 'bg-danger text-light', delay: 5000 });
        }
      });
  }

  carregarFuncionario() {
    this.servicoFuncionario.obterFuncionarioPorId(this.id)
      .subscribe((funcionario: FuncionarioDetailsViewModel) => {
        this.carregarFormulario(funcionario);
      });
  }

  carregarFormulario(funcionario: FuncionarioDetailsViewModel) {

    this.cadastroForm = new FormGroup({
      id: new FormControl(funcionario.id),
      nome: new FormControl(funcionario.nome),
      dataAdmissao: new FormControl(funcionario.dataAdmissao.toLocaleString().substring(0, 10)),
      salario:new FormControl(funcionario.salario),
      usuario: new FormControl(funcionario.usuario),
      senha: new FormControl(funcionario.senha)
    });
  }

  cancelar(): void {
    this.router.navigate(['funcionario/listar']);
  }



}
