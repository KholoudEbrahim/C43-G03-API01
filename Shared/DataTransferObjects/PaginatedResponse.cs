﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
 public record PaginatedResponse<TData>(int PageIndex, int PageSize , int TotalCount, IEnumerable<TData> data );
   
}
