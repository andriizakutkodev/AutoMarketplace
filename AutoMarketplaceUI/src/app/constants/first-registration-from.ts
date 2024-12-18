export const firstRegistrationFrom: { key: number; value: number }[] = []

for (let year = 2024; year >= 1990; year--) {
  firstRegistrationFrom.push({ key: year, value: year });
}
