using EC.Application.Interfaces;
using EC.Application.Validation;
using EC.Infra.Data.Interfaces;
using EC.Domain.ValuesObjects;
using Microsoft.Practices.ServiceLocation;

namespace EC.Application
{
    public class AppServiceBase : IAppServiceBase
    {
        private IUnitOfWork _uow;

        public virtual void BeginTransaction()
        {
            _uow = ServiceLocator.Current.GetInstance<IUnitOfWork>();
            _uow.BeginTransaction();
        }

        public virtual void Commit()
        {
            _uow.SaveChanges();
        }

        protected ValidationAppResult DomainToApplicationResult(ValidationResult result)
        {
            var validationAppResult = new ValidationAppResult();

            foreach (var validationError in result.Erros)
            {
                validationAppResult.Erros.Add(new ValidationAppError(validationError.Message));
            }
            validationAppResult.IsValid = result.IsValid;

            return validationAppResult;
        }
    }
}