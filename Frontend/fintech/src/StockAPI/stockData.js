export async function getStockData(symbol) {
  const finnhub = require("finnhub");

  const api_key = finnhub.ApiClient.instance.authentications["api_key"];
  api_key.apiKey = process.env.API_KEY;
  const finnhubClient = new finnhub.DefaultApi();

  finnhubClient.quote(symbol, (error, data, response) => {
    console.log(data);
  });
}
