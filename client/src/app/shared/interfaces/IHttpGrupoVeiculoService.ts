import { Observable } from "rxjs";
import { GrupoVeiculoCreateViewModel } from "../viewModels/grupoVeiculo/GrupoVeiculoCreateViewModel";
import { GrupoVeiculoListViewModel } from "../viewModels/grupoVeiculo/GrupoVeiculoListViewModel";

export interface IHttpGrupoVeiculoService {

    obterGrupoVeiculos(): Observable<GrupoVeiculoListViewModel[]>

    excluirGrupoVeiculo(grupoVeiculoId:number):Observable<number>

    adicionarGrupoVeiculo(grupoVeiculo: GrupoVeiculoCreateViewModel):Observable<GrupoVeiculoCreateViewModel>

}