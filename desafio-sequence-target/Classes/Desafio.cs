namespace desafio_sequence_target.Classes
{
    public class Desafio
    {
        public Guid Id { get; set; }
        public List<int> Sequencia { get; set; }
        public int Alvo { get; set; }
        public DateTime DataCriacao { get; set; }

        public Desafio(List<int> sequencia, int alvo)
        {
            if (sequencia == null || sequencia.Count == 0)
                throw new ArgumentException("Deve ser fornecido um valor para a sequencia.");
            if(sequencia.Min(x => x) <= 0)
                throw new ArgumentException("Todos os valores da sequencia devem ser maior que zero.");
            if(alvo <= 0)
                throw new ArgumentException("O valor do alvo deve ser maior que zero.");
            Guid id = Guid.NewGuid();
            Sequencia = sequencia;
            Alvo = alvo;
            DataCriacao = DateTime.Now;
        }

        public Desafio(List<int> sequencia, int alvo, DateTime dataCriacao)
            : this(sequencia, alvo)
        {
            DataCriacao = dataCriacao;
        }

        public List<int> Solucionar() {
            var solucao = new List<int>();
            var sequencia = Sequencia.Distinct().OrderByDescending(x => x).ToList();
            SolucionarRecursivo(Alvo, sequencia, solucao);
            return solucao;
        }

        private bool SolucionarRecursivo(int alvo, List<int> sequencia, List<int> solucao) {
            if (alvo == 0) return true;
            if (alvo < 0) return false;
            foreach (var numero in sequencia) {
                int qtdCombinacaoUtilizandoNumero = (int)Math.Floor((double)alvo/numero);
                for (int combinacao = qtdCombinacaoUtilizandoNumero; combinacao > 0; combinacao--) {
                    var novaSequencia = sequencia.Where(x => x != numero).ToList();
                    if (SolucionarRecursivo(alvo - numero * combinacao, novaSequencia, solucao))
                    {
                        solucao.AddRange(Enumerable.Repeat(numero, combinacao));
                        return true;
                    }
                }                
            }
            return false;
        }
    }
}
