# Sobre a API

API desenvolvida em C#/.net Core que recebe uma lista de números, chamada de Sequence, e um número alvo, chamado de Target.  
A API retorna um vetor de números caso a soma dos números do vetor atinja o número alvo, caso contrário ela retornará um vetor vazio.

Por exemplo:

A entrada:

```
{
 "Sequence": [5, 20, 2, 1],
 "Target": 47
}
```

Tem como saída:

```
[2, 5, 20, 20]
```

A entrada:

```
{
 "Sequence": [3],
 "Target": 10
}
```

Tem como saída:

```
[]
```

## Restrições

* A lista de números pode conter apenas números positivos maiores que zero.

* O valor alvo deve ser um número positivo maior que zero.