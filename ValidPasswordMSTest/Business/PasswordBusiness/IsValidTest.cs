using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ValidPasswordLib.Business
{
    [TestClass]
    public class IsValidTest
    {
        #region Testes Propostos
        [TestMethod]
        public void IsValid_TesteProposto1()
        {
            // Arrange
            var passwordBUsiness = new PasswordBusiness();
            string password = "";

            // Act
            bool result = passwordBUsiness.IsValid(password);

            // Assert
            Assert.IsFalse(result, "String vazia passou!");
        }

        [TestMethod]
        public void IsValid_TesteProposto2()
        {
            // Arrange
            var passwordBUsiness = new PasswordBusiness();
            string password = "aa";

            // Act
            bool result = passwordBUsiness.IsValid(password);

            // Assert
            Assert.IsFalse(result, "Menos de 9, com repetição, sem dígito, sem maiúscula, sem especial passou!");
        }

        [TestMethod]
        public void IsValid_TesteProposto3()
        {
            // Arrange
            var passwordBUsiness = new PasswordBusiness();
            string password = "ab";

            // Act
            bool result = passwordBUsiness.IsValid(password);

            // Assert
            Assert.IsFalse(result, "Menos de 9, sem repetição, sem dígito, sem maiúscula, sem especial passou!");
        }

        [TestMethod]
        public void IsValid_TesteProposto4()
        {
            // Arrange
            var passwordBUsiness = new PasswordBusiness();
            string password = "AAAbbbCc";

            // Act
            bool result = passwordBUsiness.IsValid(password);

            // Assert
            Assert.IsFalse(result, "Menos de 9, com repetição, sem dígito, com maiúscula, sem especial passou!");
        }

        [TestMethod]
        public void IsValid_TesteProposto5()
        {
            // Arrange
            var passwordBUsiness = new PasswordBusiness();
            string password = "AbTp9!foo";

            // Act
            bool result = passwordBUsiness.IsValid(password);

            // Assert
            Assert.IsFalse(result, "Com repetição de minúscula passou!");
        }

        [TestMethod]
        public void IsValid_TesteProposto6()
        {
            // Arrange
            var passwordBUsiness = new PasswordBusiness();
            string password = "AbTp9!foA";

            // Act
            bool result = passwordBUsiness.IsValid(password);

            // Assert
            Assert.IsFalse(result, "Com repetição de maiúscula passou!");
        }

        [TestMethod]
        public void IsValid_TesteProposto7()
        {
            // Arrange
            var passwordBUsiness = new PasswordBusiness();
            string password = "AbTp9 fok";

            // Act
            bool result = passwordBUsiness.IsValid(password);

            // Assert
            Assert.IsFalse(result, "Sem especial passou!");
        }

        [TestMethod]
        public void IsValid_TesteProposto8()
        {
            // Arrange
            var passwordBUsiness = new PasswordBusiness();
            string password = "AbTp9!fok";

            // Act
            bool result = passwordBUsiness.IsValid(password);

            // Assert
            Assert.IsTrue(result, "Senha válida não passou!");
        }
        #endregion

        #region Teste da Definição 1: Nove ou mais caracteres
        [TestMethod]
        public void IsValid_Definition1_Test1()
        {
            // Arrange
            var passwordBUsiness = new PasswordBusiness();
            string password = null;

            // Act
            bool result = passwordBUsiness.IsValid(password);

            // Assert
            Assert.IsFalse(result, "String nulla passou!");
        }

        [TestMethod]
        public void IsValid_Definition1_Test2()
        {
            // Arrange
            var passwordBUsiness = new PasswordBusiness();
            string password = "AbTp9!fo";

            // Act
            bool result = passwordBUsiness.IsValid(password);

            // Assert
            Assert.IsFalse(result, "Senha tamanho 8 passou!");
        }

        [TestMethod]
        public void IsValid_Definition1_Test3()
        {
            // Arrange
            var passwordBUsiness = new PasswordBusiness();
            string password = "AbTp9!fok";

            // Act
            bool result = passwordBUsiness.IsValid(password);

            // Assert
            Assert.IsTrue(result, "Senha tamanho 9 não passou!");
        }

        [TestMethod]
        public void IsValid_Definition1_Test4()
        {
            // Arrange
            var passwordBUsiness = new PasswordBusiness();
            string password = "AbTp9!fokK";

            // Act
            bool result = passwordBUsiness.IsValid(password);

            // Assert
            Assert.IsTrue(result, "Senha tamanho 10 não passou!");
        }

        [TestMethod]
        public void IsValid_Definition1_Test5()
        {
            // Arrange
            var passwordBUsiness = new PasswordBusiness();
            string password = "";

            // Act
            bool result = passwordBUsiness.IsValid(password);

            // Assert
            Assert.IsFalse(result, "Senha tamanho 0 passou!");
        }
        #endregion

        #region Teste da Definição 2: Ao menos 1 dígito
        [TestMethod]
        public void IsValid_Definition2_Test1()
        {
            // Arrange
            var passwordBUsiness = new PasswordBusiness();
            string password = "AbTpa!fok";

            // Act
            bool result = passwordBUsiness.IsValid(password);

            // Assert
            Assert.IsFalse(result, "Senha com 0 dígitos passou!");
        }
        #endregion

        #region Teste da Definição 3: Ao menos 1 letra minúscula
        [TestMethod]
        public void IsValid_Definition3_Test1()
        {
            // Arrange
            var passwordBUsiness = new PasswordBusiness();
            string password = "ABTP1!FOK";

            // Act
            bool result = passwordBUsiness.IsValid(password);

            // Assert
            Assert.IsFalse(result, "Senha com 0 letras minúsculas passou!");
        }
        #endregion

        #region Teste da Definição 4: Ao menos 1 letra maiúscula
        [TestMethod]
        public void IsValid_Definition4_Test1()
        {
            // Arrange
            var passwordBUsiness = new PasswordBusiness();
            string password = "abtp1!fok";

            // Act
            bool result = passwordBUsiness.IsValid(password);

            // Assert
            Assert.IsFalse(result, "Senha com 0 letras maiúsculas passou!");
        }
        #endregion

        #region Teste da Definição 5: Ao menos 1 caractere especial

        [TestMethod]
        public void IsValid_Definition5_Test1()
        {
            // Arrange
            var passwordBUsiness = new PasswordBusiness();
            string password = "abtp1Mfoku";

            // Act
            bool result = passwordBUsiness.IsValid(password);

            // Assert
            Assert.IsFalse(result, "Senha com 0 caracteres especiais passou!");
        }

        [TestMethod]
        public void IsValid_Definition5_Test2()
        {
            // Arrange
            var passwordBUsiness = new PasswordBusiness();
            string passwordBase = "abTp1fok";
            string specialChars = "!@#$%^&*()-+";

            bool result;
            string password;
            foreach (char c in specialChars)
            {
                // Arrange
                password = passwordBase + c;

                // Act
                result = passwordBUsiness.IsValid(password);

                // Assert
                Assert.IsTrue(result, $"Senha com 1 caracter especial não passou![{password}]");
            }
        }
        #endregion

        #region Teste da Definição 6: Não possuir caracteres repetidos dentro do conjunto
        [TestMethod]
        public void IsValid_Definition6_Test1()
        {
            // Arrange
            var passwordBUsiness = new PasswordBusiness();
            string password = "abTp1!fak";

            // Act
            bool result = passwordBUsiness.IsValid(password);

            // Assert
            Assert.IsFalse(result, "Senha com 1 repetição passou!");
        }
        #endregion

        #region Teste do Espaço em Branco: Espaços em branco não devem ser considerados como caracteres válidos
        [TestMethod]
        public void IsValid_WhiteSpace_Test1()
        {
            // Arrange
            var passwordBUsiness = new PasswordBusiness();
            string password = "abTp1!f k";

            // Act
            bool result = passwordBUsiness.IsValid(password);

            // Assert
            Assert.IsFalse(result, "Senha com 1 espaço em branco passou!");
        }
        #endregion
    }
}
