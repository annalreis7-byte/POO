namespace POO.Testes;

[TestClass]
[DoNotParallelize]
public sealed class AnimalTestes
{
    private StringWriter _consoleOutput;
    private TextWriter _originalOutput;

    [TestInitialize]
    public void Configurar()
    {
         _consoleOutput = new  StringWriter();
         _originalOutput = Console.Out;
         Console.SetOut(_consoleOutput);
    }

    [TestCleanup]
    public void CleanUp() // significa limpeza
    {
        Console.SetOut(_originalOutput); 
        _consoleOutput.Dispose();
        
    }
    [TestMethod]
    public void DeveRetornarObjetoCachorro_QuandoNomeEstaoCorretos()
    {
        //Arrange - Arranjo
        string nomeEsperado = "Baby";
        int  idadeEsperado = 4;
        
        //Act - ação
        var animal = new Cachorro(nomeEsperado, idadeEsperado);

        //Assert
        Assert.AreEqual(nomeEsperado, animal.Nome );
        Assert.AreEqual(idadeEsperado, animal.Idade );
        
    }
    [TestMethod]
    public void QuandoInvocadoComer_DeveEscreverMensagemPadraoNoConsole()
    {
        //Arrange - Arranjo
        string nome= "bohoby";
        var animal = new Vaca(nome, 2);
        string mensagemEsperada = $"{nome} esta comendo!{Environment.NewLine}";
            
        
        //Act - ação
       animal.Comer();

        //Assert
       
        Assert.AreEqual(mensagemEsperada, _consoleOutput.ToString());
       
    }

    [TestMethod]
    public void QuandoInvocadoFazerBarulho_DaInstanciaCachorro_DeveFazerAuAu()
    {
        //Arrange
        string nome= "Baby";
        var animal = new Cachorro(nome, 2);
        
        string mensagemEsperada = $"{nome} fez Auau{Environment.NewLine}";

        //Act
        animal.FazerBarulho();
        
        //Assert
        
        Assert.AreEqual(mensagemEsperada, _consoleOutput.ToString());
        
    }

    [TestMethod]
    public void QuandoInvocadoFazerBarulho_DaInstanciaGato_DeveFazerMiauuu()
    {
        //Arrange
        string nome= "Sallen";
        var animal = new Gato(nome, 3);
        
        string mensagemEsperada = $"{nome} fez MiauMiau{Environment.NewLine}";

        //Act
        animal.FazerBarulho();
        
        //Assert
        Assert.AreEqual(mensagemEsperada, _consoleOutput.ToString());
    }
    [TestMethod]
    public void QuandoInvocadoFazerBarulho_DaInstanciaVaca_DeveFazerMuuh()
    {
        //Arrange
        string nome= "Bohoby";
        var animal = new Vaca(nome, 2);
        
        string mensagemEsperada = $"{nome} faz Muuh{Environment.NewLine}";

        //Act
        animal.FazerBarulho();
        
        //Assert
        Assert.AreEqual(mensagemEsperada, _consoleOutput.ToString());
    }
    
    
    // unhappy Tests
    [TestMethod]
    public void QuandoInstanciarComNomeVazio_Sempre_DeveLancarArgumentException()
    {
        //Arrange
        string nomeAnimal = string.Empty;
       
        //Act
       
        var exception = Assert.ThrowsExactly<ArgumentException>(() => new Cachorro(nomeAnimal, 3));
         Assert.Contains("O nome não pode estar vazio!", exception.Message);  
    }

    [TestMethod]
    public void QuandoInstanciarComNomeNulo_Sempre_DeveLancarArgumentException()
    {
        //Arrange
        string nomeAnimal =null;
        var exception = Assert.ThrowsExactly<ArgumentException>(() => new Cachorro(nomeAnimal, 3));
        
        //Act
        Assert.Contains("O nome não pode estar vazio ou nulo!", exception.Message);  
    
    }

    [TestMethod]
    public void QuandoInstanciarComNomeNegativo_Sempre_DeveLancarArgumentException()
    {
        //Arrange
        string nomeAnimal = "Baby";
        int idadeAnimal = -2;
        var exception = Assert.ThrowsExactly<ArgumentOutOfRangeException>(() => new Cachorro(nomeAnimal, idadeAnimal));
        
        //Act
        Assert.Contains("A idade não pode ser negativo!", exception.Message);
        
    }
    
}