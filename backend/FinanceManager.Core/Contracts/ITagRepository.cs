using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceManager.Core.Contracts
{
  interface ITagRepository
  {
    string[] GetAllTags();
  }
}
