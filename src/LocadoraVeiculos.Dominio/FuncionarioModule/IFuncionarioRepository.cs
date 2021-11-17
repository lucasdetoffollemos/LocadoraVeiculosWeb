using LocadoraVeiculos.Dominio.Shared;

namespace LocadoraVeiculos.Dominio.FuncionarioModule
{
    public interface IFuncionarioRepository : IRepository<Funcionario, int>, IReadOnlyRepository<Funcionario, int>
    {
        Funcionario SelecionarFuncionarioLogado();
    }
}
