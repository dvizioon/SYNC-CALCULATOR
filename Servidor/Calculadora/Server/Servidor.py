from flask import Flask, request, jsonify, render_template
from Components.Modules.DataVw import ModulesIA
import json
import requests
import configparser
import os


config = configparser.ConfigParser()
config.read('Config.ini')
caminho_config_template = config['Paths']['PATH_TPMT']
# print(caminho_config_template );

app = Flask(__name__, template_folder=f"{caminho_config_template}")



# Rota para página de cálculo de IMC
@app.route('/imc')
def imc_page():

    return render_template('imc.html', )


# Rota para receber perguntas via API
@app.route('/api/question', methods=['POST'])
def pergunta():

    def generate_fake_user_agents(num_agents):
        user_agents = [
            "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36",
            "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/90.0.4430.212 Safari/537.36",
        ]
        
        
        if num_agents > len(user_agents):
            num_repeats = num_agents // len(user_agents) + 1
            user_agents *= num_repeats
        
        return user_agents[:num_agents]

    fake_user_agents = generate_fake_user_agents(10)
    for agent in fake_user_agents:
        # print(agent)
        user_agent = agent

    module = ModulesIA("AuthPath")
    resultado = module.render()
    
    if resultado:
        try:
            resultado_dict = json.loads(resultado)
        except json.JSONDecodeError as e:
            return jsonify({"error": "Erro ao decodificar o JSON"}), 400
        
        resultado_dict["User-Agent"] = user_agent
        resultado_json = json.dumps(resultado_dict)
        
        # Extrair dados da solicitação POST
        request_data = request.get_json()
        
        if request_data and 'altura' in request_data and 'peso' in request_data:
            altura = request_data['altura']
            peso = request_data['peso']
        else:
            altura = None
            peso = None
        
        if altura is not None and peso is not None:
            # Construir a pergunta com base nos dados recebidos
            Question = f"""
                Quero e Resposta em Português, Crie para mim uma lista para uma pessoa que tem altura de 
                {altura} e o peso de {peso} kg, me dê uma lista enumarada.
            """
        else:
            # Pergunta padrão se os dados de altura e peso não foram fornecidos corretamente
            Question = "Qual a sua pergunta?"
        
        data = {
            # Corpo da Sua Requisição
        }

        try:
            headers = {
                "Content-Type": "application/json",
                "User-Agent": user_agent,
                "token":""
            }
            
            # Enviar a requisição POST com os dados e cabeçalhos corretos
            chatRequest = requests.post("sua ai Aqui...", headers=headers, json=data)
            chatRequest.raise_for_status()
            
            formatted_content = chatRequest.content.decode('utf-8')
            response_data = {
                "response": formatted_content
            }
            
            # Redirecionar para a rota '/imc' com os parâmetros de altura e peso
            return jsonify(response_data), 200
            
        except requests.exceptions.RequestException as e:
            module = ModulesIA("Auth")
            module.render()
            return jsonify({"error": f"Erro na requisição: {e}"}), 500
    
    else:
        return jsonify({"error": "Nenhum resultado disponível"}), 404


if __name__ == '__main__':
    app.run(debug=True)
