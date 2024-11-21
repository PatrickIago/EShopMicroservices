# EShopMicroservices
Este projeto é uma implementação de microserviços utilizando ferramentas .NET em um cenário de comércio eletrônico real. Ele demonstra como construir e integrar vários módulos de microserviços, trabalhando com bancos de dados relacionais e NoSQL, além de uma comunicação eficiente baseada em eventos usando RabbitMQ.

Arquitetura do Projeto
A arquitetura do sistema é composta pelos seguintes componentes principais:

1. Aplicativos de Cliente (Shopping.Web)
A interface do usuário onde os consumidores interagem com o sistema de e-commerce. Este módulo é desenvolvido utilizando .NET 8 e serve como ponto de entrada para os usuários finais.
2. API Gateway (Yarp API Gateway)
O Yarp API Gateway funciona como um intermediário entre os aplicativos de cliente e os microserviços, roteando as requisições para os microserviços apropriados.
3. Microserviços
O sistema é dividido em vários microserviços, cada um responsável por um aspecto específico do e-commerce:

Catalog: Gerencia o catálogo de produtos. Utiliza o banco de dados PostgreSQL para armazenamento.
Basket: Gerencia o carrinho de compras. Utiliza o banco de dados Redis para armazenamento em memória, garantindo alta performance.
Discount: Responsável pela aplicação de descontos e promoções nos produtos.
Ordering: Gerencia o processamento de pedidos e transações. Utiliza SQLite e SQL Server para bancos de dados relacionais.
4. Comutação de Mensagens (RabbitMQ)
O RabbitMQ é utilizado para comunicação assíncrona entre os microserviços, permitindo a troca de mensagens e eventos entre as diferentes partes do sistema, com base em um modelo Event Driven (orientado a eventos).
5. Tecnologias Utilizadas
.NET 8: Framework para o desenvolvimento dos microserviços.
Docker: Contêinerização dos microserviços para facilitar o desenvolvimento e a implantação.
PostgreSQL, SQL Server, SQLite: Bancos de dados utilizados para armazenamento de informações.
Redis: Banco de dados NoSQL utilizado para armazenamento de dados temporários (carrinho de compras).
RabbitMQ: Broker de mensagens para a comunicação entre os microserviços.
gRPC: Usado para a comunicação eficiente e de baixo custo entre microserviços.
Funcionamento
O fluxo de dados dentro do sistema funciona da seguinte forma:

O cliente interage com o Shopping.Web, que envia as requisições para o Yarp API Gateway.
O Yarp API Gateway roteia as requisições para os microserviços apropriados.
Cada microserviço realiza sua operação específica:
O Catalog retorna os produtos.
O Basket gerencia o conteúdo do carrinho de compras.
O Discount aplica descontos aos produtos.
O Ordering processa os pedidos e transações.
O RabbitMQ garante a comunicação assíncrona e o gerenciamento de eventos entre os microserviços, promovendo a escalabilidade e o desacoplamento.
Como Rodar o Projeto
Pré-requisitos
Docker: Para rodar os containers dos microserviços.
.NET 8: Para compilar e executar os microserviços.
RabbitMQ: Para a comunicação de eventos entre os microserviços.
Passos para Executar
Clone o repositório:

bash
Copiar código
git clone <url-do-repositorio>
cd <nome-do-repositorio>
Construir e rodar os containers Docker:

bash
Copiar código
docker-compose up --build
Acesse o aplicativo de cliente em http://localhost:5000.

Endpoints da API
GET /catalog: Retorna a lista de produtos do catálogo.
POST /basket: Adiciona um produto ao carrinho de compras.
POST /order: Finaliza o pedido.
POST /discount: Aplica um desconto ao pedido.
Contribuindo
Faça um fork deste repositório.
Crie uma branch para a sua feature (git checkout -b feature/nova-feature).
Commit suas alterações (git commit -am 'Add new feature').
Push para a branch (git push origin feature/nova-feature).
Abra um pull request.
Licença
Este projeto está sob a licença MIT. Veja o arquivo LICENSE para mais detalhes.
