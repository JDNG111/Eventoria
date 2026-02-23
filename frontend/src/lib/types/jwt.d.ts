declare module 'jwt-decode' {
  export interface JwtPayload {
    nameid?: string;
    sub?: string;
    unique_name?: string;
    name?: string;
    given_name?: string;
    email?: string;
    exp?: number;
    iss?: string;
    aud?: string;
  }
  
  export function jwtDecode<T = JwtPayload>(token: string): T;
}