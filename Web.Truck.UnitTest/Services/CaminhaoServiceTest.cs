using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using Web.Truck.Data.Context;
using Web.Truck.Data.Initializer;
using Web.Truck.Domain.DTOs.Caminhao;
using Web.Truck.Domain.Entities;
using Web.Truck.Domain.Interfaces.Services;
using Web.Truck.Domain.Interfaces.Utils;
using Web.Truck.UnitTest.Factories;
using Web.Truck.UnitTest.Fixture;
using Xunit;

namespace Web.Truck.UnitTest.Services
{
    public class CaminhaoServiceTest : IClassFixture<UnitTestFixture>
    {
        private readonly ICaminhaoService _caminhaoService;
        private readonly INotificationContext _notificationContext;

        public CaminhaoServiceTest(UnitTestFixture unitTestFixture)
        {
            _caminhaoService = unitTestFixture.ServiceProvider.GetRequiredService<ICaminhaoService>();
            _notificationContext = unitTestFixture.ServiceProvider.GetRequiredService<INotificationContext>();

            var context = unitTestFixture.ServiceProvider.GetRequiredService<CaminhaoContext>();
            DbInitializer.Initialize(context);
        }

        [Theory]
        [MemberData(nameof(CaminhaoFactory.GetCaminhoesValidos), MemberType = typeof(CaminhaoFactory))]
        public void CaminhoesValidos_Validar_ComSucesso(Caminhao caminhao)
        {
            // Assert
            Assert.True(caminhao.Valido);
        }

        [Theory]
        [MemberData(nameof(CaminhaoFactory.GetCaminhoesInvalidos), MemberType = typeof(CaminhaoFactory))]
        public void CaminhoesInvalidos_Validar_ComErro(Caminhao caminhao)
        {
            // Assert
            Assert.False(caminhao.Valido);
        }

        [Theory]
        [MemberData(nameof(CaminhaoFactory.GetCaminhoesDTOValidos), MemberType = typeof(CaminhaoFactory))]
        public void CaminhoesValidos_Adicionar_ComSucesso(CaminhaoDTO caminhao)
        {
            // Act
            _notificationContext.ClearNotifications();
            _caminhaoService.Adicionar(caminhao);

            // Assert
            Assert.True(!_notificationContext.HasNotificarion()); //nenhuma notificação lançada
        }

        [Theory]
        [MemberData(nameof(CaminhaoFactory.GetCaminhoesDTOInvalidos), MemberType = typeof(CaminhaoFactory))]
        public void CaminhoesInvalidos_Adicionar_ComErro(CaminhaoDTO caminhao)
        {
            // Act
            _notificationContext.ClearNotifications();
            _caminhaoService.Adicionar(caminhao);

            // Assert
            Assert.True(_notificationContext.HasNotificarion()); //notificações lançadas
        }

        [Theory]
        [MemberData(nameof(CaminhaoFactory.GetCaminhaoDTOModeloInvalido), MemberType = typeof(CaminhaoFactory))]
        public void CaminhaoModeloInvalido_Adicionar_ComErro(CaminhaoDTO caminhao)
        {
            // Act
            _notificationContext.ClearNotifications();
            _caminhaoService.Adicionar(caminhao);

            // Assert
            Assert.True(_notificationContext.GetNotifications().ToList().FirstOrDefault().Message.Equals("Modelo não permitido."));
        }

        [Theory]
        [MemberData(nameof(CaminhaoFactory.GetCaminhaoUpdateDTOModeloValido), MemberType = typeof(CaminhaoFactory))]
        public void CaminhaoModeloValido_Atualizar_ComSucesso(CaminhaoUpdateDTO caminhao)
        {
            // Act
            _notificationContext.ClearNotifications();
            var atualizado = _caminhaoService.Atualizar(caminhao);

            // Assert
            if (!_notificationContext.HasNotificarion())
            {
                Assert.True(atualizado.Chassi.Equals("QWERTYUIOPSADFGHJKL"));
            }
            else
            {
                // ID não foi encontrado no DB (confirmando que não encontrou)
                var find = _caminhaoService.ObterTodos().Where(x => x.Id.Equals(caminhao.Id)).Any();

                Assert.False(find);
            }
        }

        [Theory]
        [InlineData(3)]
        public void Caminhao_Excluir_ComSucesso(int id)
        {
            // Act
            _notificationContext.ClearNotifications();
            _caminhaoService.Excluir(id);

            // Assert
            if (_notificationContext.HasNotificarion())
            {
                // ID não foi encontrado no DB (confirmando que não encontrou)
                var find = _caminhaoService.ObterTodos().Where(x => x.Id.Equals(id)).Any();

                Assert.False(find);
            }
            else
            {
                Assert.True(!_notificationContext.HasNotificarion());
            }
        }

        [Theory]
        [InlineData("FH")]
        [InlineData("FM")]
        public void Modelo_ValidarAceito_ComSucesso(string modelo)
        {
            // Act
            var id = _caminhaoService.SetModelo(modelo);

            // Assert
            Assert.True(!id.Equals(0));
        }

        [Theory]
        [InlineData("ST")]
        [InlineData("BM")]
        public void Modelo_ValidarAceito_ComErro(string modelo)
        {
            // Act
            var id = _caminhaoService.SetModelo(modelo);

            // Assert
            Assert.False(!id.Equals(0));
        }
    }
}
