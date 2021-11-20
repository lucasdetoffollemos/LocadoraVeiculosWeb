import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IHttpFuncionarioService } from 'src/app/shared/interfaces/IHttpFuncionarioService';
import { FuncionarioCreateViewModel } from 'src/app/shared/viewModels/funcionario/FuncionarioCreateViewModel';
import { FuncionarioDetailsViewModel } from 'src/app/shared/viewModels/funcionario/FuncionarioDetailsViewModel';
import { FuncionarioEditViewModel } from 'src/app/shared/viewModels/funcionario/FuncionarioEditViewModel';
import { FuncionarioListViewModel } from 'src/app/shared/viewModels/funcionario/FuncionarioListViewModel';

@Injectable({
  providedIn: 'root'
})
export class HttpFuncionarioService implements IHttpFuncionarioService{

  private apiUrl = 'http://localhost:32753/api/funcionario';

  constructor(private http: HttpClient) { }
 
  

  adicionarFuncionario(funcionario: FuncionarioCreateViewModel): Observable<FuncionarioCreateViewModel> {
    return this.http.post<FuncionarioCreateViewModel>(this.apiUrl, funcionario);
  }

  obterFuncionarios(): Observable<FuncionarioListViewModel[]> {
    return this.http.get<FuncionarioListViewModel[]>(this.apiUrl);
  }
  
  excluirFuncionario(funcionarioId: number): Observable<number> {
    return this.http.delete<number>(this.apiUrl + "/" + funcionarioId)
  }

  obterFuncionarioPorId(funcionarioId: number): Observable<FuncionarioDetailsViewModel> {
    return this.http.get<FuncionarioDetailsViewModel>(this.apiUrl + "/" + funcionarioId)
  }
  editarFuncionario(funcionario: FuncionarioEditViewModel): Observable<FuncionarioEditViewModel> {
    return this.http.put<FuncionarioEditViewModel>(this.apiUrl + "/" + funcionario.id, funcionario)
  }

}
