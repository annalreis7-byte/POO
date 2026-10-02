namespace POO;

public abstract class Animal
{
    public string Nome { get; private set; }
    public int Idade { get; private set; }

    protected Animal(string nome, int idade)
    {
        if (string.IsNullOrEmpty(nome))
        {
            throw new ArgumentException("O nome não pode estar vazio ou nulo!", nameof(nome));
        }

        {
            if (idade < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(idade),"A idade não pode ser negativo!");
            }
        }
        
        Nome = nome;
        Idade = idade;
    }

    public void Comer()
    {
        Console.WriteLine($"{Nome} esta comendo!");
    }

    public virtual void FazerBarulho()
    {
        Console.WriteLine($"{Nome} fez AuAuAu");
    }
}