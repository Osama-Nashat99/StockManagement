
export interface Product {
    id: number,
    name: string,
    description: string,
    categoryId: number,
    categoryName: string,
    price: number,
    serialNumber: string | null
};