import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { IHttpParceiroService } from 'src/app/shared/interfaces/IHttpParceiroService';
import { ParceiroCreateViewModel } from 'src/app/shared/viewModels/parceiro/ParceiroCreateViewModel';

@Component({
  selector: 'app-parceiro-criar',
  templateUrl: './parceiro-criar.component.html'
})
export class ParceiroCriarComponent implements OnInit {

  cadastroForm: FormGroup;
  parceiro: ParceiroCreateViewModel;

  constructor(@Inject('IHttpParceiroServiceToken') private servicoParceiro: IHttpParceiroService, private router: Router) { }

  ngOnInit(): void {
    this.cadastroForm = new FormGroup({
      nome: new FormControl('')
    });
  }

  adicionarParceiro() {
    this.parceiro = Object.assign({}, this.parceiro, this.cadastroForm.value);

    this.servicoParceiro.adicionarParceiro(this.parceiro)
      .subscribe(() => {
        this.router.navigate(['parceiro/listar']);
      });
  }

  cancelar(): void {
    this.router.navigate(['parceiro/listar']);
  }
}
