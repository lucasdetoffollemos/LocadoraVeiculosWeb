import { Observable } from "rxjs";
import { FuncionarioCreateViewModel } from "../viewModels/funcionario/FuncionarioCreateViewModel";
import { FuncionarioListViewModel } from "../viewModels/funcionario/FuncionarioListViewModel";

export interface IHttpFuncionarioService {

    adicionarFuncionario(funcionario: FuncionarioCreateViewModel): Observable<FuncionarioCreateViewModel>

    obterFuncionarios(): Observable<FuncionarioListViewModel[]>

    excluirFuncionario(funcionarioId: number): Observable<number>
}