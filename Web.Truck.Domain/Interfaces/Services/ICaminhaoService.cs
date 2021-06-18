using Web.Truck.Domain.DTOs.Caminhao;

namespace Web.Truck.Domain.Interfaces.Services
{
    public interface ICaminhaoService
    {
        void Adicionar(CaminhaoDTO CaminhaoDTO);
        void Excluir(int Id);
        CaminhaoDTO Atualizar(int Id, CaminhaoDTO CaminhaoDTO);
        CaminhaoDTO ObterTodos();

    }
}
