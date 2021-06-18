using System.Collections.Generic;
using Web.Truck.Domain.DTOs.Caminhao;

namespace Web.Truck.Domain.Interfaces.Services
{
    public interface ICaminhaoService
    {
        void Adicionar(CaminhaoDTO CaminhaoDTO);
        void Excluir(int Id);
        CaminhaoListDTO Atualizar(CaminhaoUpdateDTO CaminhaoDTO);
        IEnumerable<CaminhaoListDTO> ObterTodos();

    }
}
