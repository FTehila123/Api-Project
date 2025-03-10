﻿using chineseAction.Models;

namespace chineseAction.Dal
{
    public interface IPresentDal
    {
        public List<PresentMask> GetPresent();
        public PresentMask Add(PresentMask present);
        public void Delete(int id);
        public PresentMask GetById(int id);
        public void Update(Present newPresent);
        public List<Present> GetByBuyers(int num);
        public List<Present> GetByName(string name);
        public List<PresentMask> GetByDonaterId(int id);
    }
}
