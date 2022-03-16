import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IHttpGrupoVeiculoService } from 'src/app/shared/interfaces/IHttpGrupoVeiculoService';
import { GrupoVeiculoCreateViewModel } from 'src/app/shared/viewModels/grupoVeiculo/GrupoVeiculoCreateViewModel';
import { GrupoVeiculoListViewModel } from 'src/app/shared/viewModels/grupoVeiculo/GrupoVeiculoListViewModel';

@Injectable({
  providedIn: 'root'
})
export class HttpGrupoVeiculoService implements IHttpGrupoVeiculoService{


  private apiUrl = 'http://localhost:32753/api/grupoVeiculo';

  constructor(private http: HttpClient) { }


  adicionarGrupoVeiculo(grupoVeiculo: GrupoVeiculoCreateViewModel): Observable<GrupoVeiculoCreateViewModel> {
    return this.http.post<GrupoVeiculoCreateViewModel>(this.apiUrl, grupoVeiculo);
  }
  
  obterGrupoVeiculos():Observable<GrupoVeiculoListViewModel[]>{

   return this.http.get<GrupoVeiculoListViewModel[]>(this.apiUrl);
  }

  excluirGrupoVeiculo(grupoVeiculoId: number): Observable<number> {
    return this.http.delete<number>(this.apiUrl + "/" + grupoVeiculoId)
  }

}
