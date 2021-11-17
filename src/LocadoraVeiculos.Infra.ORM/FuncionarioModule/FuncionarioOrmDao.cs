
using LocadoraVeiculos.Dominio.FuncionarioModule;
using System;
using System.Linq;

namespace LocadoraVeiculos.Infra.ORM.FuncionarioModule
{
    public class FuncionarioOrmDao : RepositoryOrmBase<Funcionario, int>, IFuncionarioRepository
    {
        public FuncionarioOrmDao(LocadoraDbContext db) : base(db)
        {
        }

        public Funcionario SelecionarFuncionarioLogado()
        {
            var funcionario = db.Funcionarios
                            .FirstOrDefault();

            if (funcionario == null)
            {
                funcionario = new Funcionario("Alexandre Rech", "rech", "123", DateTime.Now.Date, 1000.0);
                base.Inserir(funcionario);
            }

            return funcionario;
        }
    }
}