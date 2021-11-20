import { Observable } from "rxjs";
import { FuncionarioCreateViewModel } from "../viewModels/funcionario/FuncionarioCreateViewModel";
import { FuncionarioDetailsViewModel } from "../viewModels/funcionario/FuncionarioDetailsViewModel";
import { FuncionarioEditViewModel } from "../viewModels/funcionario/FuncionarioEditViewModel";
import { FuncionarioListViewModel } from "../viewModels/funcionario/FuncionarioListViewModel";

export interface IHttpFuncionarioService {

    adicionarFuncionario(funcionario: FuncionarioCreateViewModel): Observable<FuncionarioCreateViewModel>

    obterFuncionarios(): Observable<FuncionarioListViewModel[]>

    excluirFuncionario(funcionarioId: number): Observable<number>

    obterFuncionarioPorId(funcionarioId: number): Observable<FuncionarioDetailsViewModel>

    editarFuncionario(funcionario: FuncionarioEditViewModel): Observable<FuncionarioEditViewModel>

}