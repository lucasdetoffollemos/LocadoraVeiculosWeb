import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IHttpTaxaService } from 'src/app/shared/interfaces/IHttpTaxaService';
import { TaxaCreateViewModel } from 'src/app/shared/viewModels/taxa/TaxaCreateViewModel';
import { TaxaDetailsViewModel } from 'src/app/shared/viewModels/taxa/TaxaDetailsViewModel';
import { TaxaEditViewModel } from 'src/app/shared/viewModels/taxa/TaxaEditViewModel';
import { TaxaListViewModel } from 'src/app/shared/viewModels/taxa/TaxaListViewModel';


@Injectable({
  providedIn: 'root'
})
export class HttpTaxaService implements IHttpTaxaService {

  private apiUrl = 'http://localhost:32753/api/taxa';

    constructor(private http: HttpClient) { }

    public obterTaxas(): Observable<TaxaListViewModel[]> {
        return this.http.get<TaxaListViewModel[]>(`${this.apiUrl}`);
    }

    public adicionarTaxa(taxa: TaxaCreateViewModel): Observable<TaxaCreateViewModel> {
        return this.http.post<TaxaCreateViewModel>(this.apiUrl, taxa);
    }

    public obterTaxaPorId(taxaId: number): Observable<TaxaDetailsViewModel> {
        return this.http.get<TaxaDetailsViewModel>(`${this.apiUrl}/${taxaId}`);
    }

    public editarTaxa(taxa: TaxaEditViewModel): Observable<TaxaEditViewModel> {
        return this.http.put<TaxaEditViewModel>(`${this.apiUrl}/${taxa.id}`, taxa);
    }

    public excluirTaxa(taxaId: number): Observable<number> {
        return this.http.delete<number>(`${this.apiUrl}/${taxaId}`);
    }
}
