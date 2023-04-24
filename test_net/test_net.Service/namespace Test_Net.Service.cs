using System;
using System.Collections.Generic;
using System.Data;
using Test_Net.DataAccess;
using Test_Net.DTO.Testing;

namespace Test_Net.Service
{
    public class WebServicesUserStoryService
    {
        private readonly WebServicesUserStoryRepository _repository;

        public WebServicesUserStoryService(WebServicesUserStoryRepository repository)
        {
            _repository = repository;
        }

        public WebServicesUserStory GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Create(WebServicesUserStory story)
        {
            _repository.Create(story);
        }

        public void Update(WebServicesUserStory story)
        {
            _repository.Update(story);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public IEnumerable<WebServicesUserStory> GetAll()
        {
            return _repository.GetAll();
        }
    }
}