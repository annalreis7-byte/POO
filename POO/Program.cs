namespace POO;

static class Program
{
    static void Main(string[] args)
    {

        Animal[] animais =
        [

            new Cachorro("Baby", 5),
            new Gato("Sallen", 3),
            new Vaca("Baaby", 2),

        ];
        foreach (Animal animalAtual in animais)
        {
            animalAtual.Comer();
            animalAtual.FazerBarulho();
            
        }
        

    }
}

