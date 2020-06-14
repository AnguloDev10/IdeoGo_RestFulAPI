using IdeoGo.API.Domain.Models;
using IdeoGo.API.Domain.Repositories;
using IdeoGo.API.Domain.Services;
using IdeoGo.API.Domain.Services.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeoGo.API.Services
{
    public class SubscriptionService : ISubscriptionService
    {

        private readonly ISubscriptionRepository _subscriptionRepository;
        public readonly IUnitOfWork _unitOfWork;

        public SubscriptionService(ISubscriptionRepository subscriptionRepository, IUnitOfWork unitOfWork)
        {
            _subscriptionRepository = subscriptionRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Subscription>> ListAsync()
        {
            return await _subscriptionRepository.ListAsync();
        }


        public async Task<SubscriptionResponse> GetByIdAsync(int id)
        {
            var existingSubscription = await _subscriptionRepository.FindByIDAsync(id);

            if (existingSubscription == null)
                return new SubscriptionResponse("Subscription not found");
            return new SubscriptionResponse(existingSubscription);
        }

        async Task<SubscriptionResponse> ISubscriptionService.SaveAsync(Subscription subscription)
        {
            try
            {
                await _subscriptionRepository.AddAsync(subscription);

                return new SubscriptionResponse(subscription);
            }
            catch (Exception ex)
            {
                return new SubscriptionResponse($"An error ocurred while saving the Subscription: {ex.Message}");
            }
        }

        async Task<SubscriptionResponse> ISubscriptionService.UpdateAsync(int id, Subscription subscription)
        {
            var existingSubscription = await _subscriptionRepository.FindByIDAsync(id);

            if (existingSubscription == null)
                return new SubscriptionResponse("Subscription not found");

            existingSubscription.Name = subscription.Name;

            try
            {
                _subscriptionRepository.Update(existingSubscription);

                return new SubscriptionResponse(existingSubscription);
            }
            catch (Exception ex)
            {
                return new SubscriptionResponse($"An error ocurred while updating Subscription: {ex.Message}");
            }
        }

        async Task<SubscriptionResponse> ISubscriptionService.DeleteAsync(int id)
        {
            var existingSubscription = await _subscriptionRepository.FindByIDAsync(id);

            if (existingSubscription == null)
                return new SubscriptionResponse("Subscription not found");

            try
            {
                _subscriptionRepository.Remove(existingSubscription);

                return new SubscriptionResponse(existingSubscription);
            }
            catch (Exception ex)
            {
                return new SubscriptionResponse($"An error ocurred while deleting Subscription: {ex.Message}");
            }
        }
    }
}
