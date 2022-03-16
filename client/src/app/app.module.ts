import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FooterComponent } from './navegacao/footer/footer.component';
import { HeaderComponent } from './navegacao/header/header.component';
import { MenuComponent } from './navegacao/menu/menu.component';
import { HomeComponent } from './home/home.component';
import { ParceiroListarComponent } from './parceiro/listar/parceiro-listar.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { ParceiroCriarComponent } from './parceiro/criar/parceiro-criar.component';
import { RouterModule } from '@angular/router';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ParceiroEditarComponent } from './parceiro/editar/parceiro-editar.component';
import { CupomListarComponent } from './cupom/listar/cupom-listar.component';
import { CupomCriarComponent } from './cupom/criar/cupom-criar.component';
import { CupomEditarComponent } from './cupom/editar/cupom-editar.component';
import { HttpParceiroService } from './parceiro/services/http-parceiro.service';
import { HttpCupomService } from './cupom/services/http-cupom.service';
import { FuncionarioCriarComponent } from './funcionario/criar/funcionario-criar.component';
import { FuncionarioListarComponent } from './funcionario/listar/funcionario-listar.component';
import { HttpFuncionarioService } from './funcionario/services/http-funcionario.service';
import { EditarFuncionarioComponent } from './funcionario/editar/editar-funcionario.component';
import { ToastContainerComponent } from './shared/components/toast-container/toast-container.component';

import ptBr from '@angular/common/locales/pt';
import { registerLocaleData } from '@angular/common';
import { FormatarEnumPipe } from './shared/pipes/formatar-enum.pipe';
import { TaxaCriarComponent } from './taxa/criar/taxa-criar.component';
import { TaxaListarComponent } from './taxa/listar/taxa-listar.component';
import { TaxaEditarComponent } from './taxa/editar/taxa-editar.component';
import { HttpTaxaService } from './taxa/services/http-taxa.service';
import { GrupoVeiculoListarComponent } from './grupoVeiculo/listar/grupo-veiculo-listar.component';
import { HttpGrupoVeiculoService } from './grupoVeiculo/services/http-grupo-veiculo.service';
import { GrupoVeiculoCriarComponent } from './grupoVeiculo/criar/grupo-veiculo-criar.component';

registerLocaleData(ptBr);


@NgModule({
  declarations: [
    AppComponent,
    FooterComponent,
    HeaderComponent,
    MenuComponent,
    HomeComponent,
    ParceiroListarComponent,
    ParceiroCriarComponent,
    ParceiroEditarComponent,
    CupomListarComponent,
    CupomCriarComponent,
    CupomEditarComponent,
    FuncionarioCriarComponent,
    FuncionarioListarComponent,
    EditarFuncionarioComponent,
    ToastContainerComponent,
    FormatarEnumPipe,
    TaxaCriarComponent,
    TaxaListarComponent,
    TaxaEditarComponent,
    GrupoVeiculoListarComponent,
    GrupoVeiculoCriarComponent

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    RouterModule,
    FormsModule,
    NgbModule
  ],
  providers: [
    { provide: 'IHttpParceiroServiceToken', useClass: HttpParceiroService },
    { provide: 'IHttpCupomServiceToken', useClass: HttpCupomService },
    { provide: 'IHttpFuncionarioServiceToken', useClass: HttpFuncionarioService },
    { provide: 'IHttpTaxaServiceToken', useClass: HttpTaxaService },
    { provide: 'IHttpGrupoVeiculoServiceToken', useClass: HttpGrupoVeiculoService },
    { provide: 'LOCALE_ID', useValue: 'pt' }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
