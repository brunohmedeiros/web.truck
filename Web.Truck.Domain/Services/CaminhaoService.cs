using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using Web.Truck.Domain.DTOs.Caminhao;
using Web.Truck.Domain.Entities;
using Web.Truck.Domain.Interfaces.Data.UoW;
using Web.Truck.Domain.Interfaces.Services;
using Web.Truck.Domain.Interfaces.Utils;
using Web.Truck.Domain.Validations;

namespace Web.Truck.Domain.Services
{
    public class CaminhaoService : BaseService, ICaminhaoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CaminhaoService(IUnitOfWork unitOfWork, IMapper mapper, INotificationContext notificationContext) : base(notificationContext)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Adicionar(CaminhaoDTO CaminhaoDTO)
        {
            try
            {
                var cam = _mapper.Map<Caminhao>(CaminhaoDTO);

                if (!cam.Valido)
                {
                    AddNotify(cam.ValidationResult);
                    return;
                }

                cam.ModeloId = SetModelo(CaminhaoDTO.Modelo);

                if (cam.ModeloId.Equals(0))
                {
                    return;
                }

                _unitOfWork.Repository<Caminhao>().Create(cam);
                _unitOfWork.Salvar();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public CaminhaoListDTO Atualizar(CaminhaoUpdateDTO CaminhaoDTO)
        {
            try
            {
                var find = _unitOfWork.Repository<Caminhao>().GetByQuery(x => x.Id.Equals(CaminhaoDTO.Id)).FirstOrDefault();

                if (find is null)
                {
                    AddNotify("Id não encontrado.");
                    return null;
                }

                find.AnoFabricacao = CaminhaoDTO.AnoFabricacao;
                find.AnoModelo = CaminhaoDTO.AnoModelo;
                find.Chassi = CaminhaoDTO.Chassi;
                find.ModeloId = SetModelo(CaminhaoDTO.Modelo);

                if (find.ModeloId.Equals(0))
                {
                    return null;
                }

                find.Validar(find, new CaminhaoValidator());

                if (!find.Valido)
                {
                    AddNotify(find.ValidationResult);
                    return null;
                }

                _unitOfWork.Repository<Caminhao>().Update(find);
                _unitOfWork.Salvar();

                return _mapper.Map<CaminhaoListDTO>(_unitOfWork.Repository<Caminhao>()
                    .GetByQuery(x => x.Modelo)
                    .Where(x => x.Id.Equals(CaminhaoDTO.Id))
                    .FirstOrDefault());
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Excluir(int Id)
        {
            try
            {
                var find = _unitOfWork.Repository<Caminhao>().GetByQuery(x => x.Id.Equals(Id)).FirstOrDefault();

                if (find is null)
                {
                    AddNotify("Id não encontrado.");
                    return;
                }

                _unitOfWork.Repository<Caminhao>().Delete(find);
                _unitOfWork.Salvar();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<CaminhaoListDTO> ObterTodos()
        {
            try
            {
                return _mapper.Map<IEnumerable<CaminhaoListDTO>>(_unitOfWork.Repository<Caminhao>()
                    .GetByQuery(x => x.Modelo)
                    .OrderByDescending(x => x.Id));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int SetModelo(string Modelo)
        {
            if (Modelo.ToUpper().Contains("FH") || Modelo.ToUpper().Contains("FM"))
            {
                return _unitOfWork.Repository<Modelo>().GetByQuery(x => x.Descricao.Equals(Modelo.ToUpper())).FirstOrDefault().Id;
            } 
            else
            {
                AddNotify("Modelo não permitido.");
            }

            return 0;
        }
    }
}
