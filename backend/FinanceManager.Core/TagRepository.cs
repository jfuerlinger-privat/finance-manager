using FinanceManager.Core.Contracts;
using System;

namespace FinanceManager.Core
{
  public class TagRepository : ITagRepository
  {
    private readonly string[] _tags = new[] { "Lea", "Joe", "Dani", "Hautarzt", "Zahnarzt", "Kinderarzt" };

    public string[] GetAllTags() => _tags;
  }
}
