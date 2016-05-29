using AutoMapper;
using EC.Application.ViewModel;
using EC.Domain.Entities.Clientes;
using EC.Domain.Entities.Geografia;
using EC.Domain.Entities.Produtos;
using EC.Domain.Entities.Vendas;

namespace EC.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Cliente, ClienteViewModel>()
                .ForMember(dest => dest.Enderecos, opt => opt.MapFrom(src => src.EnderecoList));

            Mapper.CreateMap<Cliente, ClienteEnderecoViewModel>();
            Mapper.CreateMap<Endereco, ClienteEnderecoViewModel>();
            Mapper.CreateMap<Categoria, CategoriaViewModel>();
            Mapper.CreateMap<Produto, ProdutoViewModel>();
            Mapper.CreateMap<Endereco, EnderecoViewModel>();

            Mapper.CreateMap<Venda, VendaViewModel>();

        }
    }
}