import axios from "axios";

export async function getStockData(symbol) {
  const env = process.env.VUE_APP_API_KEY;

  const result = await axios.get(
    `https://finnhub.io/api/v1/quote?token=${env}&symbol=${symbol}`
  );
  console.log(result.data);
}
