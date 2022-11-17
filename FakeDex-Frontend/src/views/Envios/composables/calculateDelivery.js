export const setDelivery = (lat1, lat2, lng1, lng2) => {
  const rad = function (x) {
    return (x * Math.PI) / 180;
  };
  const R = 6378.137;
  const dLat = rad(lat2 - lat1);
  const dLong = rad(lng2 - lng1);
  const a =
    Math.sin(dLat / 2) * Math.sin(dLat / 2) +
    Math.cos(rad(lat1)) *
      Math.cos(rad(lat2)) *
      Math.sin(dLong / 2) *
      Math.sin(dLong / 2);
  const c = 2 * Math.atan2(Math.sqrt(a), Math.sqrt(1 - a));
  const d = R * c;
  return d.toFixed(3);
};
