namespace btg_testes_auto
{
    // sugestão Theory/InlineData
    public class AnaliseSuspeitos
    {
        public string ExecutarQuestionarioSuspeito(bool telefonouVitima, bool esteveNoLocal, bool moraPerto, bool devedor, bool trabalhaComVitima)
        {
            int respostasPositivas = 0;

            if (telefonouVitima) respostasPositivas++;

            if (esteveNoLocal) respostasPositivas++;

            if (moraPerto) respostasPositivas++;

            if (devedor) respostasPositivas++;

            if (trabalhaComVitima) respostasPositivas++;

            switch (respostasPositivas)
            {
                case 2:
                    return "Suspeita";
                case 3:
                case 4:
                    return "Cúmplice";
                case 5:
                    return "Assassino";
                default:
                    return "Inocente";
            }
        }
    }
}
