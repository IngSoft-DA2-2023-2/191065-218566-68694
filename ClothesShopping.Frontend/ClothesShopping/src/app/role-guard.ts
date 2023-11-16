// role.guard.ts
import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';

@Injectable({
  providedIn: 'root',
})
export class RoleGuard implements CanActivate {
  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
    const expectedRole = (route.data as any).expectedRole;

    // Aquí podrías verificar el rol del usuario almacenado en el localStorage o de donde lo obtengas.
    debugger
    const userRole = localStorage.getItem('userRol');

    if (userRole && userRole === expectedRole) {
      return true;
    }

    // Si el usuario no tiene el rol esperado, redirige a una página de acceso no autorizado o la página que desees.
    this.router.navigate(['/products']);
    return false;
  }

  constructor(private router: Router) {}
}
