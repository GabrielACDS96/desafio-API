using desafio_sequence_target.Classes;

namespace desafio_sequence_target.Data
{
    public class DesafioRepository
    {
        private DesafioContext Context { get; set; }

        public DesafioRepository(DesafioContext context)
        {
            Context = context;
        }

        public List<Desafio> Obter(DateTime? dataInicial, DateTime? dataFinal) {
            IEnumerable<Desafio> desafios = Context.Desafio;
            if (dataInicial.HasValue) 
                desafios = desafios.Where(x => x.DataCriacao >= dataInicial);
            if (dataFinal.HasValue)
                desafios = desafios.Where(x => x.DataCriacao <= dataFinal);
            return desafios.ToList();
        }

        public void Adicionar(Desafio desafio) {
            Context.Desafio.Add(desafio);
            Context.SaveChanges();
        }
    }
}
