using System;
using prop_central_netcore.Data.Interfaces;

namespace prop_central_netcore.Service
{
	public class FlatService
	{
		private readonly IFlatRepository _flatRepository;

        public FlatService(IFlatRepository flatRepository )
		{
			_flatRepository = flatRepository;
		}


	}
}

