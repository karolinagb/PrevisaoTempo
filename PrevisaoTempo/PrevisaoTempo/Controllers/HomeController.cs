using Microsoft.AspNetCore.Mvc;
using PrevisaoTempo.Models;
using PrevisaoTempo.Models.ViewModels;
using PrevisaoTempo.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace PrevisaoTempo.Controllers
{
    public class HomeController : Controller
    {
        private readonly PrevisaoClimaRepository _previsaoClimaRepository;
        private readonly CidadeRepository _cidadeRepository;

        public HomeController(PrevisaoClimaRepository previsaoClimaRepository, CidadeRepository cidadeRepository)
        {
            _previsaoClimaRepository = previsaoClimaRepository;
            _cidadeRepository = cidadeRepository;
        }

        public async Task<IActionResult> Index(int idCidade)
        {
            var previsoesCidadesMaisQuentes = await _previsaoClimaRepository
                .ObterCidadesMaisQuentes(3);

            var previsoesCidadesMaisFrias = await _previsaoClimaRepository
               .ObterCidadesMaisFrias(3);

            var cidades = await _cidadeRepository.Get();

            PrevisaoCidadeViewModel previsaoCidadeViewModel = new PrevisaoCidadeViewModel();
            previsaoCidadeViewModel.PrevisoesMaxima = previsoesCidadesMaisQuentes;
            previsaoCidadeViewModel.PrevisoesMinima = previsoesCidadesMaisFrias;
            previsaoCidadeViewModel.Cidades = cidades;
            previsaoCidadeViewModel.Id = idCidade;

            if (idCidade > 0)
            {
                previsaoCidadeViewModel.CidadeEPrevisoes = await _cidadeRepository.ObterCidadeEPrevisoes(idCidade);
            }

            return View(previsaoCidadeViewModel);
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
