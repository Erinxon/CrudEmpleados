export interface ApiResponse<T> {
    totalRegistros: number;
    pageNumber: number;
    pageSize: number;
    data: T;
    succeeded: boolean;
    message: string;
    erros: string[];
}